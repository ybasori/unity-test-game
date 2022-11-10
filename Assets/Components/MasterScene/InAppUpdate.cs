using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.AppUpdate;
using Google.Play.Common;
using TMPro;

public class InAppUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text inAppStatus;
    [SerializeField] private TMP_Text logStatus;
    AppUpdateManager appUpdateManager;

    private IEnumerator CheckForUpdate()
    {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation =
            appUpdateManager.GetAppUpdateInfo();

        // wait until the asynchronous operation completes.
        yield return appUpdateInfoOperation;

        if (appUpdateInfoOperation.IsSuccessful)
        {
            var appUpdateInfoResult  = appUpdateInfoOperation.GetResult();
            // Check AppUpdateInfo's UpdateAvailability, UpdatePriority,
            // IsUpdateTypeAllowed(), etc. and decide whether to ask the user
            // to start an in-app update.

            logStatus.text = appUpdateInfoResult.UpdateAvailability.ToString();
            logStatus.text = logStatus.text + "\n" + UpdateAvailability.UpdateAvailable.ToString();

            //display if there is an update or not
            if (appUpdateInfoResult.UpdateAvailability == UpdateAvailability.UpdateAvailable)
            {
                inAppStatus.text = UpdateAvailability.UpdateAvailable.ToString();              
            }
            else
            {
                inAppStatus.text = "No Update Available";
            }

            // Creates an AppUpdateOptions defining an immediate in-app
            // update flow and its parameters.
            var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateUpdate(appUpdateInfoResult , appUpdateOptions));
            
            

        }
    }

    IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInfoOp_i, AppUpdateOptions appUpdateOptions_i)
    {
        // Creates an AppUpdateRequest that can be used to monitor the
        // requested in-app update flow.
        var startUpdateRequest = appUpdateManager.StartUpdate(
            // The result returned by PlayAsyncOperation.GetResult().
            appUpdateInfoOp_i,
                      // The AppUpdateOptions created defining the requested in-app update
                      // and its parameters.
                      appUpdateOptions_i
            );
        yield return startUpdateRequest;

        // If the update completes successfully, then the app restarts and this line
        // is never reached. If this line is reached, then handle the failure (for
        // example, by logging result.Error or by displaying a message to the user).
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!Debug.isDebugBuild)
        {
            StopAllCoroutines();
            appUpdateManager = new AppUpdateManager();
            StartCoroutine(CheckForUpdate());
        }
    }

}
