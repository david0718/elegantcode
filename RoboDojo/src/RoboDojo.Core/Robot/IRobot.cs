using System;
using System.ComponentModel;
using System.Drawing;

namespace RoboDojo.Core.Robot
{
    public interface IRobot : INotifyPropertyChanged
    {
        int Energy { get; }
        Color DisplayColor { get; }
        string Author { get; }
        Guid ID { get; }
        string Name { get; }
        string Version { get; }
        Rectangle FootPrint { get; }
    }
}