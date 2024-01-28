using System.Text.RegularExpressions;

namespace IPLOG_Assembly_Parser
{
    public partial class Form1 : Form
    {
        readonly private static string pathToFile = "C:/source.txt";
        readonly Parser parser = new(pathToFile);

        public Form1() { InitializeComponent(); }

        private void BttParse_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            PopulateViewTree(parser.ConvertIOToIPLOG());
        }

        private void PopulateViewTree(List<IOModule> IOModules)
        {
            TreeNode rootNode = new("ROOT IPLOG", ConvertIOModulesToNodes(IOModules));
            treeView.Nodes.Add(rootNode);
        }

        private static TreeNode[] ConvertIOModulesToNodes(List<IOModule> IOModules)
        {
            TreeNode[] nodes = new TreeNode[IOModules.Count];
            for (int index = 0; index < IOModules.Count; index++)
            {
                if (IOModules[index].IFModule.inputs == 0) { nodes[index] = new TreeNode("IO addr: " + index.ToString()); }
                else { nodes[index] = new TreeNode("IO addr: " + index.ToString(), AddIFModule()); }
            }

            return nodes;
        }

        private static TreeNode[] AddIFModule()
        {
            TreeNode[] module = new TreeNode[1];
            module[0] = new TreeNode("IF Module");

            return module;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<IOModule> IOModules = parser.ConvertIOToIPLOG();
            if (treeView.SelectedNode.Text == "ROOT IPLOG")
            {
                int inputs = 0;
                int outputs = 0;
                int IFModules = 0;

                for (int index = 0; index < IOModules.Count; index++)
                {
                    inputs += IOModules[index].inputs;
                    inputs += IOModules[index].IFModule.inputs;
                    outputs += IOModules[index].outputs;
                    outputs += IOModules[index].IFModule.outputs;
                    if (IOModules[index].IFModule.inputs != 0)
                    {
                        inputs += IOModules[index].IFModule.inputs;
                        IFModules++;
                    }
                }

                labelInputsCount.Text = inputs.ToString();
                labelOutputsCount.Text = outputs.ToString();
                labelIFModulesCount.Text = IFModules.ToString();
            }
            else if (treeView.SelectedNode.Text == "IF Module")
            {
                TreeNode parentNode = treeView.SelectedNode.Parent;
                labelInputsCount.Text = IOModules[Int32.Parse(Regex.Match(parentNode.Text, @"\d+").Value)].IFModule.inputs.ToString();
                labelOutputsCount.Text = IOModules[Int32.Parse(Regex.Match(parentNode.Text, @"\d+").Value)].IFModule.outputs.ToString();
                labelIFModulesCount.Text = "0";
            }
            else
            {
                labelIFModulesCount.Text = CheckForIFModule(IOModules, treeView.SelectedNode);
                labelInputsCount.Text = CheckForInputs(IOModules, treeView.SelectedNode);
                labelOutputsCount.Text = CheckForOutputs(IOModules, treeView.SelectedNode);
            }
        }

        private static string CheckForOutputs(List<IOModule> IOModules, TreeNode selectedNode)
        {
            if (CheckForIFModule(IOModules, selectedNode) == "0") { return IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].outputs.ToString(); }
            return (IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].outputs
                    + IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].IFModule.outputs)
                    .ToString();
        }

        private static string CheckForIFModule(List<IOModule> IOModules, TreeNode selectedNode)
        {
            if (IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].IFModule.inputs == 0) { return "0"; }
            return "1";
        }

        private static string CheckForInputs(List<IOModule> IOModules, TreeNode selectedNode)
        {
            if (CheckForIFModule(IOModules, selectedNode) == "0") { return IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].inputs.ToString(); }
            return (IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].inputs
                    + IOModules[Int32.Parse(Regex.Match(selectedNode.Text, @"\d+").Value)].IFModule.inputs)
                    .ToString();
        }
    }
}
