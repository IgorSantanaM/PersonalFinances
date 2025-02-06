resource "azurerm_container_app_environment" "app_env" {
  location = azurerm_resource_group.personal_finances_rg.location
  name = "personalfinancesappenv${var.env_id}"
  resource_group_name = azurerm_resource_group.personal_finances_rg.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.law.id

  tags = {
        environment = var.env_id
        src = var.src_key
    }
}