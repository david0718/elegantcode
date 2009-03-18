namespace RoboDojo.Core.Robot
{
    public abstract partial class RobotBase : IRobot
    {
        public event WeaponFiredHandler OnFiredWeapon;
        public event RobotDamagedHandler OnTookDamage;
        public event RobotDiedHandler OnDied;

        private void InvokeOnTookDamage(RobotEventArgs args)
        {
            RobotDamagedHandler Handler = OnTookDamage;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnDied(RobotEventArgs args)
        {
            RobotDiedHandler Handler = OnDied;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnFiredWeapon(WeaponFiredEventArgs args)
        {
            WeaponFiredHandler Handler = OnFiredWeapon;
            if (Handler != null) Handler(this, args);
        }
    }
}