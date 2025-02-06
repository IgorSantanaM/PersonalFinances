resource "azurerm_log_analytics_workspace" "law" {
  location = azurerm_resource_group.personal_finances_rg.location
  name = "personalfinanceslaw${var.env_id}"
  resource_group_name = azurerm_resource_group.personal_finances_rg.name
  sku = "PerGB2018"
  retention_in_days = 30
}