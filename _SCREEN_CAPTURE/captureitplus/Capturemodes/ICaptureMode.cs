namespace CaptureItPlus
{
    using System.Drawing;
    using System.Windows.Forms;

    public interface ICaptureMode
    {
        string Name { get; }
        string Text { get; }
        bool IsEnabled { get; }
        void Initialize(params object[] arguments);
        string Execute();
    }
}
