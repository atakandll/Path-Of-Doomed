using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeedBack : MonoBehaviour
{
    public abstract void CreateFeedBack();

    // before we destroy this object.
    public abstract void CompletePreviousFeedBack(); // createfeedbackten önce bu olucak bunu çağırıcaz createfeedback metotunu kullandığımız yerlerde

    protected virtual void OnDestroy()
    {
        CompletePreviousFeedBack(); // reset values befor we destroy our game object
        // önceki geri bildirimi tamamlayın
    }

}
