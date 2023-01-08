[![Build Status](https://dev.azure.com/bm1905/FinancePlanner/_apis/build/status/bm1905.FinancePlanner.FinanceServices?branchName=master)](https://dev.azure.com/bm1905/FinancePlanner/_build/latest?definitionId=6&branchName=master)

# FinancePlanner.FinanceServices

## Running Database Migration
1. Run `Add-Migration -o Migrations InitialCreate` to create migration script inside directory Migrations.
2. Run `Update-Database` to create schema in database.