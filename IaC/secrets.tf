# Define the Key Vault resource
resource "azurerm_key_vault" "key_vault" {
  name                        = "personalfinanceskv-${var.env_id}"
  resource_group_name         = azurerm_resource_group.personal_finances_rg.name
  location                    = azurerm_resource_group.personal_finances_rg.location
  tenant_id = var.tenant_id
  sku_name = "standard"
}

resource "azurerm_key_vault_secret" "subscription_id" {
  name         = "subscription-id"
  value        = var.subscription_id
  key_vault_id = azurerm_key_vault.key_vault.id
}

resource "azurerm_key_vault_secret" "tenant_id" {
  name         = "tenant-id"
  value        = var.tenant_id
  key_vault_id = azurerm_key_vault.key_vault.id
}

resource "azurerm_key_vault_access_policy" "key_vault_policy" {
  key_vault_id = azurerm_key_vault.key_vault.id
  tenant_id    = var.tenant_id
  object_id    = var.object_id 

  secret_permissions = [
    "Get",
    "Set"
  ]
}

data "azurerm_key_vault_secret" "subscription_id" {
  name         = "subscription-id"
  key_vault_id = azurerm_key_vault.key_vault.id 
  depends_on = [azurerm_key_vault_secret.subscription_id] 
}

data "azurerm_key_vault_secret" "tenant_id" {
  name         = "tenant-id"
  key_vault_id = azurerm_key_vault.key_vault.id 

  depends_on = [azurerm_key_vault_secret.tenant_id] 
}

locals {
  subscription_id = data.azurerm_key_vault_secret.subscription_id.value
  tenant_id = data.azurerm_key_vault_secret.tenant_id.value
}