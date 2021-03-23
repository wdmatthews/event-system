# event-system
A scriptable object based event system with cross scene compatability.
## Installation
You can download the entire Assets/Event System folder,
or just the Assets/Event System/LICENSE and Assets/Event System/Scripts.
The 2D Sprite, Unity UI, and TextMeshPro packages are required for the demo to function.
They can be installed from the Unity Package Manager.
Make sure to Import TMP Essential Resources from Window/TextMeshPro.
## Documentation
### EventManagerSO
EventManagerSO stores all of the events assigned to it through subscriptions.
In order to use it, you have to create an Event System/Event Manager asset from the create asset menu.
That reference will be stored in an EventSubscriber to subscribe/unsubscribe to/from or trigger events.
Because the event manager is a scriptable object, it can be accessed from multiple scenes.
If an EventSubscriber or its GameObject is destroyed, whether directly or with a scene load,
it will be removed from events when they are next triggered.
### Subscribing to an Event
To subscribe to an event, add an EventSubscriber to the GameObject you want subscribed,
then assign your EventManagerSO in the inspector.
In your code, you can invoke EventSubscriber.Subscribe with your component reference.
There are five different events, one with no data passed, a string, an int, a float, or a GameObject.
### Unsubscribing from an Event
Unsubscribing has similar API to subscribing, but will take an action or EventSubscriber out of an event.
EventSubscriber.Unsubscribe is used to unsubscribe from an event,
with the same parameters used to subscribe.
### Triggering an Event
To trigger an event, invoke EventSubscriber.Trigger, passing in data if needed.
If you trigger an event that does not exist, nothing will happen.
For example, you could trigger "pickup-item", but if no EventSubscribers subscribed to
"pickup-item", then the event will not exist and therefore nothing will happen.