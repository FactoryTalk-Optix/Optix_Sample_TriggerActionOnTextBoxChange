# VariableChange example

This example shows how to trigger an action when a variable's value is changed, in this example we use a `TextBox` to trigger a boolean variable for 1sec when the Text is edited

## Logic

Under the `TextBox` we created a `Runtime NetLogic` which observes the `TextVariable` object, when the Text is changed, the `MyVar_VariableChange` method is executed and the boolean variable pointed by `VariableToTrigger` (children of the NetLogic) is changed to **true**, then a `DelayedTask` is created and after a certain amount of time, a new method is called to reset the variable.

## Disclaimer

Rockwell Automation maintains these repositories as a convenience to you and other users. Although Rockwell Automation reserves the right at any time and for any reason to refuse access to edit or remove content from this Repository, you acknowledge and agree to accept sole responsibility and liability for any Repository content posted, transmitted, downloaded, or used by you. Rockwell Automation has no obligation to monitor or update Repository content

The examples provided are to be used as a reference for building your own application and should not be used in production as-is. It is recommended to adapt the example for the purpose, observing the highest safety standards.
