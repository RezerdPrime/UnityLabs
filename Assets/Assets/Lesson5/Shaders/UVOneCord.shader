Shader "Unlit/UVOneCord"
{
    Properties
    {
        _Axis("Axis", int) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" } // Очередь для отрисовки 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            fixed _Axis;
            // Информация о модели
            struct appdata //meshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };


            // Информация о фрагментах полученная из векторов
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };


            // Обработка на уровне векторов скорее всего меньше всего влияет на производительность
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // Локальные координаты в экранные
                // o.vertex = v.vertex; // Положение на экране
                // o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = v.uv;
                return o;
            }

            // Обработка на уровне фрагментов
            fixed4 frag (v2f i) : SV_Target
            {
                float temp = i.uv.x * (1 + _Axis)/2 - i.uv.y * (_Axis - 1)/2;
                return fixed4(temp  , temp, temp, 1);
            }
            ENDCG
        }
    }
}
