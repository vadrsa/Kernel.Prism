using System.Windows;

namespace Kernel.Workitems
{
    public class ModalOptions
    {
        static Size DefaultSize = new Size(800, 500);
        static ResizeMode DefaultResizeMode = ResizeMode.CanResize;
        static WindowStartupLocation DefaultStartupLocation = WindowStartupLocation.CenterOwner;
        static bool DefaultIsDialog = false;

        public ModalOptions()
        {
            Size = DefaultSize;
            ResizeMode = DefaultResizeMode;
            WindowStartupLocation = DefaultStartupLocation;
            IsDialog = DefaultIsDialog;
        }

        public ModalOptions(Size size) : this()
        {
            Size = size;
        }

        public ModalOptions(Size size, ResizeMode resizeMode) : this(size)
        {
            ResizeMode = resizeMode;
        }

        public ModalOptions(Size size, ResizeMode resizeMode, WindowStartupLocation startupLocation) : this(size, resizeMode)
        {
            WindowStartupLocation = startupLocation;
        }

        public ModalOptions(Size size, ResizeMode resizeMode, WindowStartupLocation startupLocation, bool isDialog) : this(size, resizeMode, startupLocation)
        {
            IsDialog = isDialog;
        }

        public WindowStartupLocation WindowStartupLocation { get; }

        public Size Size { get; }

        public ResizeMode ResizeMode { get; }

        public bool IsDialog { get; }
    }
}
