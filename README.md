# DevExpress-Report-With-MySQL
Use Pomelo.EntityFrameworkCore.MySql and DevExpress.Reporting at the same time

There are three ways to allow DevExpress.Reporting to use the default connection string
1. Set XpoProvider in Default Connection String on design time, and remove it on Runtime.
2. Use ConfigurationBuilder extension services to override the default connection string provider to get connection strings from a set of different configuration sources,
3. Custom Connection String Provider, implement the IDataSourceWizardConnectionStringsProvider interface to create a custom connection string provider.

This sample is using methor 1.
