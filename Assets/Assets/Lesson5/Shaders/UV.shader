Shader "Unlit/UV"
{
    Properties
    {
        // Параметры получаемые извне
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" } // Очередь для отрисовки 
        LOD 100 // Уровень деталей - в зависимости от расстояния до объекта можно прописать разное поведение

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _MainTex_ST;
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
                // sample the texture
                // fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                return fixed4(i.uv.x, i.uv.y, 0, 1);
            }
            ENDCG
        }
    }
}
