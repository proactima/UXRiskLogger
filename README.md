UXRiskLogger
============

Description
-----------
This is a modified version of ninject/ninject.extensions.logging

Basically, it's ninject.extensions.logging, ninject.extensions.logging/log4net and NinjectAutoLogging (http://rationalgeek.com/blog/introducing-ninjectautologging/).
We've modified the Logger object to add some extra logger methods, and use the newly created object to store everything to an Azure table.

There are two demo projects included, one to demonstrate usage in a Console application using a ConsoleAppender, and one MVC project using Azure Table storage as the logging target.
The Azure code in this demo is based on this blog post (http://blog.tylerdoerksen.com/2012/04/17/logging-in-azure-part-2table-storage).