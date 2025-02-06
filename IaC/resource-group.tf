resource "azurerm_resource_group" "personal_finances_rg" {
  location = "UK South"
  name = "personal-finances-rg"

  tags = {
    environment = var.env_id
    src = var.src_key
  }
}