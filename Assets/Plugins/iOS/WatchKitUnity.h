//
//  WatchKitUnity.h
//
//  Created by Nikos Chagialas - http://devgallery.com on 10/04/2015
//
//

#import <WatchKit/WatchKit.h>
#import <Foundation/Foundation.h>
#import "MMWormhole.h"

@interface WatchKitUnity : NSObject

@property (nonatomic, strong) MMWormhole *wormhole;

- (void)initialiseWithGroup:(NSString *)group;
- (void)registerListenerFor:(NSString *)identifier;
- (void)sendMessage:(NSString *)value toObject:(NSString *)theObject withIdentifier:(NSString *)identifier;


@end

