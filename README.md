Week 4 Lab - ASP.NET MVC
-------------------------------

Goals:
----

* Able to create a mvc app
* Style the mvc using bootstrap
* Use Routing to have a dynamic set of pages
* Pass data from the controller to the views to render
* Use Model Binding to collect information from a view


Requirements:
----

1. Craft a MVC app that shows your Surf and Paddle (can expand from week 3 lab)
1. Make the pages dynamic, where:
  * The root page shows the latest post
  * The images at the bottom of the page link link to that post
  * When viewing that post (URL will be /posts/:name) it shows that post
1. Make a Create Post page that allows you to create a post and save it to the list of current posts.
1. Make a Edit Post page that allows you to edit a post and update the list of current posts
1. Make a Delete Post page that allows you to delete a post and remove it from the list of current posts

posts should be something like this:

```c#
var posts = new List<Post>()
posts.Add(new Post(id: 1, title: "waffles", Image:"waffles.jpg", Text: "waffles are the best...", Category : Category.Food)
posts.Add(new Post(id: 2, title: "pancakes", Image:"pancakes.jpg", Text: "pancakes are the best...", Category : Category.Food)
posts.Add(new Post(id: 3, title: "bacon", Image:"bacon.jpg", Text: "bacon is the best...", Category : Category.Food)
```

Notes:
-----

* To find an element in your `posts` lists by id you can do: `posts.First(p=>p.Id == 5)`
* There is no database in this lab, but we will have databases next week. So to save information put it in Session, Application, or Cache


Nightmare Mode
---

1. Add a user authentication system. So to be able to create, edit, delete posts requires authentication
2. The authentication system needs a login page and authenticate against a hard-coded list of usernames and passwords.
3. 
