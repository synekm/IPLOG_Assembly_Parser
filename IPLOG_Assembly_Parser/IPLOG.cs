﻿namespace IPLOG_Assembly_Parser
{
    internal class Module
    {
        public int inputs;
        public int outputs;
    }

    internal class IOModule : Module
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

    internal class IFModule : Module
    {
        public IFModule(int inputs, int outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }
    }
}
