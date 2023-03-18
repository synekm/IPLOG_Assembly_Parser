namespace IPLOG_Assembly_Parser
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            bttParse = new Button();
            labelInputs = new Label();
            labelOutputs = new Label();
            labelIFModules = new Label();
            labelInputsCount = new Label();
            labelOutputsCount = new Label();
            labelIFModulesCount = new Label();
            treeView = new TreeView();
            SuspendLayout();
            // 
            // bttParse
            // 
            bttParse.Location = new Point(218, 11);
            bttParse.Margin = new Padding(2);
            bttParse.Name = "bttParse";
            bttParse.Size = new Size(75, 23);
            bttParse.TabIndex = 1;
            bttParse.Text = "Parse";
            bttParse.UseVisualStyleBackColor = true;
            bttParse.Click += BttParse_Click;
            // 
            // labelInputs
            // 
            labelInputs.AutoSize = true;
            labelInputs.Location = new Point(12, 252);
            labelInputs.Margin = new Padding(2, 0, 2, 0);
            labelInputs.Name = "labelInputs";
            labelInputs.Size = new Size(43, 15);
            labelInputs.TabIndex = 2;
            labelInputs.Text = "Inputs:";
            // 
            // labelOutputs
            // 
            labelOutputs.AutoSize = true;
            labelOutputs.Location = new Point(12, 267);
            labelOutputs.Margin = new Padding(2, 0, 2, 0);
            labelOutputs.Name = "labelOutputs";
            labelOutputs.Size = new Size(53, 15);
            labelOutputs.TabIndex = 3;
            labelOutputs.Text = "Outputs:";
            // 
            // labelIFModules
            // 
            labelIFModules.AutoSize = true;
            labelIFModules.Location = new Point(12, 282);
            labelIFModules.Margin = new Padding(2, 0, 2, 0);
            labelIFModules.Name = "labelIFModules";
            labelIFModules.Size = new Size(68, 15);
            labelIFModules.TabIndex = 4;
            labelIFModules.Text = "IF Modules:";
            // 
            // labelInputsCount
            // 
            labelInputsCount.AutoSize = true;
            labelInputsCount.Location = new Point(79, 252);
            labelInputsCount.Margin = new Padding(2, 0, 2, 0);
            labelInputsCount.Name = "labelInputsCount";
            labelInputsCount.Size = new Size(13, 15);
            labelInputsCount.TabIndex = 4;
            labelInputsCount.Text = "0";
            // 
            // labelOutputsCount
            // 
            labelOutputsCount.AutoSize = true;
            labelOutputsCount.Location = new Point(79, 267);
            labelOutputsCount.Margin = new Padding(2, 0, 2, 0);
            labelOutputsCount.Name = "labelOutputsCount";
            labelOutputsCount.Size = new Size(13, 15);
            labelOutputsCount.TabIndex = 4;
            labelOutputsCount.Text = "0";
            // 
            // labelIFModulesCount
            // 
            labelIFModulesCount.AutoSize = true;
            labelIFModulesCount.Location = new Point(79, 282);
            labelIFModulesCount.Margin = new Padding(2, 0, 2, 0);
            labelIFModulesCount.Name = "labelIFModulesCount";
            labelIFModulesCount.Size = new Size(13, 15);
            labelIFModulesCount.TabIndex = 4;
            labelIFModulesCount.Text = "0";
            // 
            // treeView
            // 
            treeView.Location = new Point(12, 11);
            treeView.Name = "treeView";
            treeView.Size = new Size(201, 238);
            treeView.TabIndex = 5;
            treeView.AfterSelect += TreeView_AfterSelect;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 310);
            Controls.Add(bttParse);
            Controls.Add(labelInputs);
            Controls.Add(labelOutputs);
            Controls.Add(labelIFModules);
            Controls.Add(labelInputsCount);
            Controls.Add(labelOutputsCount);
            Controls.Add(labelIFModulesCount);
            Controls.Add(treeView);
            Name = "Form1";
            Text = "IPLOG assembly parser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button bttParse;
        private System.Windows.Forms.Label labelInputs;
        private System.Windows.Forms.Label labelOutputs;
        private System.Windows.Forms.Label labelIFModules;
        private System.Windows.Forms.Label labelInputsCount;
        private System.Windows.Forms.Label labelOutputsCount;
        private System.Windows.Forms.Label labelIFModulesCount;
        private System.Windows.Forms.TreeView treeView;
    }
}