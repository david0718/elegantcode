using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using RoboDojo.Core.Robot;

namespace RoboDojo.WinFormRunner.Service
{
    public class RobotLoader
    {
        public void LoadRobotAssembly(string assemblyFilePath)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(assemblyFilePath);
                LoadAssemblyRobots(assembly);
            }
            catch (Exception ex)
            {
                InvokeOnAssemblyLoadErrored(new AssemblyLoadErrorHandlerArgs(assemblyFilePath, ex));
                return;
            }
            

        }

        private void LoadAssemblyRobots(Assembly assembly)
        {
            Type[] types = assembly.GetExportedTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsSubclassOf(typeof(RobotBase)))
                {
                    try
                    {
                        var robot = assembly.CreateInstance(types[i].FullName) as RobotBase;
                        if (robot != null)
                            InvokeOnRobotLoaded(new RobotLoadedHandlerArgs(robot));
                    }
                    catch (Exception ex)
                    {
                        InvokeOnTypeLoadedErrored(new TypeLoadErrorHandlerArgs(types[i].FullName, ex));
                    }
                }
            }
        }

        #region Loading Event Stuff
        public event RobotLoadedHandler OnRobotLoaded;
        public event AssemblyLoadErrorHandler OnAssemblyLoadErrored;
        public event TypeLoadErrorHandler OnTypeLoadedErrored;

        public delegate void RobotLoadedHandler(object sender, RobotLoadedHandlerArgs args);
        public delegate void AssemblyLoadErrorHandler(object sender, AssemblyLoadErrorHandlerArgs args);
        public delegate void TypeLoadErrorHandler(object sender, TypeLoadErrorHandlerArgs args);

        public class RobotLoadedHandlerArgs
        {
            public RobotBase Robot { get; private set; }

            public RobotLoadedHandlerArgs(RobotBase robot)
            {
                Robot = robot;
            }
        }

        public class TypeLoadErrorHandlerArgs
        {
            public string TypeName { get; private set; }
            public Exception Exception { get; private set; }

            public TypeLoadErrorHandlerArgs(string typeName, Exception exception)
            {
                TypeName = typeName;
                Exception = exception;
            }
        }

        public class AssemblyLoadErrorHandlerArgs
        {
            public string AssemblyFilename { get; private set; }
            public Exception Exception { get; private set; }

            public AssemblyLoadErrorHandlerArgs(string assemblyFilename, Exception exception)
            {
                AssemblyFilename = assemblyFilename;
                Exception = exception;
            }
        }

        private void InvokeOnRobotLoaded(RobotLoadedHandlerArgs args)
        {
            RobotLoadedHandler Handler = OnRobotLoaded;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnAssemblyLoadErrored(AssemblyLoadErrorHandlerArgs args)
        {
            AssemblyLoadErrorHandler Handler = OnAssemblyLoadErrored;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnTypeLoadedErrored(TypeLoadErrorHandlerArgs args)
        {
            TypeLoadErrorHandler onTypeLoadedErroredHandler = OnTypeLoadedErrored;
            if (onTypeLoadedErroredHandler != null) onTypeLoadedErroredHandler(this, args);
        }

        #endregion
    }
}