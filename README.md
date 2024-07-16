# OclcApiTest
In the Config.cs file are two variables that need to be set.

They are OclcClientId and OclcClientSecret.

In the Program.cs file there are two methods of concern GetOclc and SaveOclc.

The GetOclc successfully gets a publication from the worldcat/manage/bibs endpoint.
The method is to verify that the received bearer token works.

The SaveOclc method is one with a problem.

When Postman POSTs the API as reproduced in SaveOclc, Postman generates a 400 Bad Request and 14 validation errors.

The expected results of SaveOclc should be the same as Postman: a 400 Bad Request and 14 validation errors.

The current results of SaveOclc is a 406 Not Acceptable.
Title is "Invalid 'Content-Type' header."
Detail is "A request with an invalid 'Content-Type' header was attempted: application/marcxml+xml; charset=utf-8".

My question is what do I need to change in SaveOclc to return the same results as Postman and to not have an invalid 'Content-Type' header.
