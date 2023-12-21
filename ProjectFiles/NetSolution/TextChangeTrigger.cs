#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
#endregion

public class TextChangeTrigger : BaseNetLogic
{
    public override void Start()
    {
        // Get the variable that receives the trigger
        targetVar = InformationModel.GetVariable(LogicObject.GetVariable("VariableToTrigger").Value);
        // Sync to the variable change event
        myVar = ((TextBox)Owner).TextVariable;
        myVar.VariableChange += MyVar_VariableChange;
    }

    public override void Stop()
    {
        // Dispose the variable watcher
        myVar.VariableChange -= MyVar_VariableChange;
    }

    private void MyVar_VariableChange(object sender, VariableChangeEventArgs e)
    {
        // Log some information
        Log.Info("Old value: " + e.OldValue.ToString());
        Log.Info("New value: " + e.NewValue.ToString());
        // Set the trigger variable to true
        targetVar.Value = true;
        // Prepare the delayed action
        resetValue?.Dispose();
        resetValue = new DelayedTask(resetVariable, 1000, LogicObject);
        resetValue.Start();
    }

    private void resetVariable()
    {
        // Reset the variable
        targetVar.Value = false;
    }

    private DelayedTask resetValue;
    private IUAVariable targetVar;
    private IUAVariable myVar;
}
