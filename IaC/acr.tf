resource "azurerm_container_registry" "acr" {
    location = azurerm_resource_group.personal_finances_rg.location
    name = "personalfinancesregistry${var.env_id}"
    resource_group_name = azurerm_resource_group.personal_finances_rg.name
    sku = "Standard"
    admin_enabled = true
    public_network_access_enabled = true 

    tags = {
        environment = var.env_id
        src = var.src_key
    }
}