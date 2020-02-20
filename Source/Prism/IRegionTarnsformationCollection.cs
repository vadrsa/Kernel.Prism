using Kernel.Prism;
using System;

namespace Kernel
{
    public interface IRegionTransformationCollection
    {
        IRegionTransformation GetTransformation(Type type);
    }
}
