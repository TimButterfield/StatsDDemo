# StatsD Example

### Instrumenting our code is essential to

* give us visibility of what's happening on our production systems
* enable us to detect production issues
* make healthy choices so we can focus our efforts in the correct places

### Enter StatsD

There are lots of potential solutions but StatsD is one of the quickest ways for us to start instrumenting our code, due to StatsD and the DataDog agents being installed on the webservers. StatsD is a possibility of the how, but we need to work the what and the why too. 

### To get us thinking

This repo is a VERY simple piece of code to get us talking about and thinking about where we'd record metrics, what metrics we'd record and why. It's delierately simple, so that we don't get distracted by code. Your task then is to : 

* Read the code, gain a quick understanding and work out if there is any metric you'd want to record, and why. Or why you wouldn't want to record anything. 

If you're looking for a starting point, go to ./StatsDExample/Consumer.cs

We'll discuss ideas, and once we've done that I'll demonstrate to you what's possible (the how). It doesn't matter if you don't have any thoughts on the metics, there's no pressure to come up with an answer, since the goal is discussion.