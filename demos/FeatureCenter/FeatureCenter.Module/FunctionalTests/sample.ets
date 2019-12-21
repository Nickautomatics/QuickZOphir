;#DropDB FeatureCenterEasyTest

#Application FeatureCenter.Win
#Application FeatureCenter.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef FeatureCenter.Win

*Action About...
 
*Action OK

#EndIf

#IfDef FeatureCenter.Web
*Action Navigation(My Details)
#EndIf
