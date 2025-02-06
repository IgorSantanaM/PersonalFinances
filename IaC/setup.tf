terraform {
  required_providers {
    azurerm = {
        source = "hashicorp/azurerm"
        version = "4.17.0"
    }
  }
#   backend "azurerm" {
#     resource_resource_group_name = "reference-rg"
#     storage_storage_account_name = "myiacfiles"
#     containercontainer_name = "terraform"
#     key = "terraform.tfstate"    
#   }
}
provider "azurerm"{
    features {
    }
    subscription_id = var.subscription_id
}