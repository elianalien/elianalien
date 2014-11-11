import tweepy
#from tweepy import OAuthHandler

consumer_key="qhoesZx6Co4IssBn0CYwtUZuY"
consumer_secret="SzavqLvJZDdFnTW71UyBhQy2qnOShgqlBeW3vhkhAG0v6NsuTM"
access_token="1339310466-HQ1tV6lc1odu3JqRrry8o1SzfzusFPZNeWJdOU8"
access_token_secret="Uj6SfgOqwqck0G6tNKqXah2k72EgdVKl15jMAQ3IbmrWP"

auth = tweepy.OAuthHandler(consumer_key, consumer_secret)
auth.set_access_token(access_token, access_token_secret)

api = tweepy.API(auth)
#Cursor(api.home_timeline)
#for tweet in Cursor(api.home_timeline).items(200):
#    process_status(tweet)
    
home_tweets = api.home_timeline(count=25)
for tweet in home_tweets:
	print tweet.user.name 
	print tweet.text
	print tweet.created_at
	print tweet.source
	print 
	#print tweet.user.profile_image_url
