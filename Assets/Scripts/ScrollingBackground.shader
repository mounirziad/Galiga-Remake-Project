Shader "Custom/ScrollingBackground"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ScrollSpeed("Scroll Speed", Float) = 0.1
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _ScrollSpeed;

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv + float2(0, _ScrollSpeed * _Time.y);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    return tex2D(_MainTex, i.uv);
                }
                ENDCG
            }
        }
}
