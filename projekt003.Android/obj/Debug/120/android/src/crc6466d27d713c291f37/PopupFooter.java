package crc6466d27d713c291f37;


public class PopupFooter
	extends android.widget.RelativeLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRequestSendAccessibilityEvent:(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)Z:GetOnRequestSendAccessibilityEvent_Landroid_view_View_Landroid_view_accessibility_AccessibilityEvent_Handler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.PopupLayout.PopupFooter, Syncfusion.SfPopupLayout.XForms.Android", PopupFooter.class, __md_methods);
	}


	public PopupFooter (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PopupFooter.class) {
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.PopupLayout.PopupFooter, Syncfusion.SfPopupLayout.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public PopupFooter (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PopupFooter.class) {
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.PopupLayout.PopupFooter, Syncfusion.SfPopupLayout.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public PopupFooter (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PopupFooter.class) {
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.PopupLayout.PopupFooter, Syncfusion.SfPopupLayout.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public PopupFooter (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == PopupFooter.class) {
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.PopupLayout.PopupFooter, Syncfusion.SfPopupLayout.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}


	public boolean onRequestSendAccessibilityEvent (android.view.View p0, android.view.accessibility.AccessibilityEvent p1)
	{
		return n_onRequestSendAccessibilityEvent (p0, p1);
	}

	private native boolean n_onRequestSendAccessibilityEvent (android.view.View p0, android.view.accessibility.AccessibilityEvent p1);


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
