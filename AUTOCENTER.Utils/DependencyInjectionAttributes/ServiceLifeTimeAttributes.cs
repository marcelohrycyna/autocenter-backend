namespace AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes
{
    public class TransientAttribute : Attribute
    {
        public TransientAttribute()
        {
        }
    }

    public class ScopedAttribute : Attribute
    {
        public ScopedAttribute()
        {
        }
    }

    public class SingletonAttribute : Attribute
    {
        public SingletonAttribute()
        {
        }
    }
}