/*
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour {

	void Awake () {
		Advertisement.Initialize ("1117219", false);
	}


	void Update () {}

	public void ShowDefaultAd(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show();
		}
	}
	public void ShowRewardedAd(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show("rewardedVideo");
			Advertisement.Show();
		}
	}

}
*/

using UnityEngine;
using admob;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class AdsManager : MonoBehaviour
{
	public void ShowDefaultAd()
	{
		#if UNITY_ADS
		if (!Advertisement.IsReady())
		{
			Debug.Log("Ads not ready for default zone");
			return;
		}

		Advertisement.Show();
		#endif
	}

	public void ShowRewardedAd()
	{
		const string RewardedZoneId = "rewardedVideo";

		#if UNITY_ADS
		if (!Advertisement.IsReady(RewardedZoneId))
		{
			Debug.Log(string.Format("Ads not ready for zone '{0}'", RewardedZoneId));
			return;
		}

		var options = new ShowOptions { resultCallback = HandleShowResult };
		Advertisement.Show(RewardedZoneId, options);
		#endif
	}


	private void Start(){
		
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance().initAdmob ("ca-app-pub-2241817318169719/3514313588","ca-app-pub-2241817318169719/9421246383");
		Admob.Instance ().loadInterstitial ();
		#endif

		ShowBanner();
	}

	public void ShowBanner(){
		#if UNITY_EDITOR
		Debug.Log("Banner Ads are showing");
		#elif UNITY_ANDROID
		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_CENTER, 5);
		#endif
	}

	public void ShowVideo(){
		#if UNITY_EDITOR
		Debug.Log("Video Ads are showing");
		#elif UNITY_ANDROID
		if (Admob.Instance ().isInterstitialReady()) {
			Admob.Instance ().showInterstitial ();
		}
		#endif
	}


	#if UNITY_ADS
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
	#endif
}