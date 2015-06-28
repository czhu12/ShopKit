
//
//  WatchKitUnity.mm
//
//  Created by Nikos Chagialas - http://devgallery.com on 10/04/2015
//
//

#import "WatchKitUnity.h"

@implementation WatchKitUnity

extern void UnitySendMessage(const char *, const char *, const char *);

- (id)init
{
    self = [super init];
    return self;
}

- (void)initialiseWithGroup:(NSString *)group 
{
	self.wormhole = [[MMWormhole alloc] initWithApplicationGroupIdentifier:group optionalDirectory:@"wormhole"];
}

- (void)registerListenerFor:(NSString *)identifier
{
    [self.wormhole listenForMessageWithIdentifier:identifier listener:^(id messageObject) {
        NSLog(identifier);
        UnitySendMessage("WatchKitUnityManager", "onMessageReceived", [identifier UTF8String]);
    }];       
}

- (void)sendMessage:(NSString *)value toObject:(NSString *)theObject withIdentifier:(NSString *)identifier
{
 	[self.wormhole passMessageObject:@{theObject : value} identifier:identifier];
}


@end

static WatchKitUnity* delegateObject = nil;


// Converts C style string to NSString
NSString* CreateNSString (const char* string)
{
	if (string)
		return [NSString stringWithUTF8String: string];
	else
		return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* MakeStringCopy (const char* string)
{
	if (string == NULL)
		return NULL;
	
	char* res = (char*)malloc(strlen(string) + 1);
	strcpy(res, string);
	return res;
}

// When native code plugin is implemented in .mm / .cpp file, then functions
// should be surrounded with extern "C" block to conform C function naming rules
extern "C" {

	void _InitialiseWithGroup (const char* group)
	{
		if (delegateObject == nil)
			delegateObject = [[WatchKitUnity alloc] init];
		
		[delegateObject initialiseWithGroup: CreateNSString(group)];
	}
	
	void _RegisterListenerFor (const char* identifier)
	{
		[delegateObject registerListenerFor: CreateNSString(identifier)];
	}
	
	void _SendMessage (const char* value, const char* theObject, const char* identifier)
	{
		[delegateObject sendMessage: CreateNSString(value) toObject: CreateNSString(theObject) withIdentifier: CreateNSString(identifier)];
	}
	
}

