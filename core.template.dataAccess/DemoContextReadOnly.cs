namespace core.template.dataAccess
{
    using System;

    public class DemoContextReadOnly : DemoContext
    {
        public override int SaveChanges()
        {
            throw new InvalidOperationException("This is a Read-Only Context");
        }
    }
}
