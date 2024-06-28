I have completed my challenge.
You should be able to click start in Visual Studio and have the app start up.
There is an Apply button at the top where you can access the form.

It took 2 hours.

I chose to use MVC Razor (based off the VS template you get given) as I felt this would be more familar to me but I had to get used to ViewComponents which were brand new when I last used it.

I chose to use a service for business logic and a repository to mimic the types of DB/other storage requests that would be made and a static ConcurrentDictionary to hold the data for the lifetime of the application.
(I recognise this is not a permanent store.)
I added some unit tests in areas of this app that performed calculations.  Given more time I would have added more to other classes too.
Use of AutoFixture and Shoudly or FluentAssertions too.

If a DB was used some of the summary calculations may have been done in the SP itself, ensuring transactions.

Had I had more time I would have elaborated on the unit tests.
Maybe I would have split out some of the rules into their own classes and broken the app down even more, however I just wanted to demonstrate that type of thinking in what I produced here (sometimes it's not necessary).

Further enhancements would have been to actually log.

In terms of meeting the requirements obviously the request loan cannot be more than the value, this wasn't listed as a requirement - it would be easy to add. I would have queried given this task in real life.
There are similar things I could think of.

My aim would be good robust unit tests, simple code, well broken down.