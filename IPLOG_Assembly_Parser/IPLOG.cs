using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLOG_Assembly_Parser
{
    internal class IOModule : IFModule
    {
        public int address;
        public IFModule IFModule;

        public IOModule(int address, int inputs, int outputs, IFModule IFModule)
        {
            this.address = address;
            this.inputs = inputs;
            this.outputs = outputs;
            this.IFModule = IFModule;
        }
    }

    internal class IFModule
    {
        public int inputs;
        public int outputs;

        public IFModule(int inputs, int outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }
    }
}
