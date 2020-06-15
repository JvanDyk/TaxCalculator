TaxCalculator

Basic Tax Calculator with a Razor MVC Front-end and a .net core 3 back-end microservice.

MVC stands for Model-View-Controller pattern, which inherently is made of 3 different patterns which is also why it's called the compount pattern. Which could also be reffered to as pattern of patterns.

The 3 patterns of MVC:

Strategy pattern: The controller is strategy for the view. It’s the object that knows how to handle the user actions. The view is the object that is configured with strategy. The view is concerned only with the visual aspects of the applications, and delegates to the controller for any decisions about the interface behavior.

Observer pattern: The model implements the observer pattern to keep interested objects updated when state changes occur. Using the observer pattern keeps the model completely independent of view and controller. It allows us to use different views with the same model, or even multiple views at once.

Composite pattern: The display consists of a nested set of windows, panel, buttons, text label and so on. Each display component is a composite. When the controller tells the view to update. It only has to tell the top view components, and composite takes care of that.

I've used the principle of "Favor composition of inheritance" for the model. Because I've used the "enacapsulated what varies" principle.
Essentially I've Extended compositional behaviour to the model depending on what kind of tax calculation needed to be done by depending on an interface rather than a concretational Calculation to it. Because I've seperated what varies to ensured that the client isn't forced to depend on methods it doesn't use. it's basically acting on the Interface segregation principle.

The back-end and the front-end also uses the "Dependency inversion"" principle such as the TaxCalculatorTransportService or the HttpClientFactory or Configuration settings, that I'm injecting the depencies via the Controller and service constructors when instantiated on the application startup initialization.
