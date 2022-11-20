import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;


public class VolleyAdapter {
    private static RequestQueue requestQueue = Volley.newRequestQueue(Common.getAppContext());

    public static void post(String url,
                     JSONObject jsonObjectBody,
                     Response.Listener<JSONObject> responseListener,
                     VolleyAdapter.ErrorListener errorListener) {

        JsonObjectRequest jsonObjReq = new JsonObjectRequest(Request.Method.POST,
                url,
                jsonObjectBody,
                responseListener,
                volleyError -> errorListener.onErrorResponse(volleyError, getFormattedMessage(volleyError))) {
            @Override
            public Map<String, String> getHeaders() {
                Map<String, String> params = new HashMap<>();
                params.put("Content-Type", "application/json");
                return params;
            }
        };

        requestQueue.add(jsonObjReq);
    }

    private static String getFormattedMessage(VolleyError volleyError) {
        String formattedMessage = "";
        formattedMessage += Integer.toString(volleyError.networkResponse.statusCode);
        formattedMessage += ": ";
        formattedMessage += volleyError.toString();
        formattedMessage += ",\n";
        formattedMessage += new String(volleyError.networkResponse.data);
        return formattedMessage;
    }

    public interface ErrorListener {
        void onErrorResponse(VolleyError volleyError, String formattedErrorMessage);
    }
}
