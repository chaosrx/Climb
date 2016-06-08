/*******************************************************
 * 													   *
 * Asset:		 Smart First Person Controller 		   *
 * Script:		 SurfaceDetector.cs                    *
 * 													   *
 * Copyright(c): Victor Klepikov					   *
 * Support: 	 http://bit.ly/vk-Support			   *
 * 													   *
 * mySite:       http://vkdemos.ucoz.org			   *
 * myAssets:     http://u3d.as/5Fb                     *
 * myTwitter:	 http://twitter.com/VictorKlepikov	   *
 * 													   *
 *******************************************************/


using UnityEngine;

namespace SmartFirstPersonController
{
    public sealed class SurfaceDetector : ScriptableObject
    {
        [System.Serializable]
        public sealed class SurfaceData
        {
            public string name = string.Empty;
            public Material[] materials = null;
            public Texture[] textures = null;
        }

        [SerializeField]
        private SurfaceData[] surfaces = null;
        

        // instance
        private static SurfaceDetector instance = null;
        // m_Instance
        private static SurfaceDetector m_Instance
        {
            get
            {
                if( instance == null )
                    instance = Resources.Load<SurfaceDetector>( "SurfaceDetector" );
                
                return instance;
            }
        }


        // Get SurfaceName ByHit
        public static string GetSurfaceNameByHit( RaycastHit hit )
        {
            int tmpIndex = GetSurfaceIndexByHit( hit );
            return ( tmpIndex > -1 ) ? m_Instance.surfaces[ tmpIndex ].name : "Unknown Surface";
        }
        // Get SurfaceIndex ByHit
        public static int GetSurfaceIndexByHit( RaycastHit hit )
        {
            const int negativeIndex = -1;

            Collider hitCollider = hit.collider;
            if( hitCollider == null || hitCollider.isTrigger )
                return negativeIndex;

            // if TerrainTexture != null, return it.
            Texture tmpTex = GetTerrainTextureByHit( hit );
            if( tmpTex != null )
            {
                for( int i = 0; i < GetCount; i++ )
                    foreach( Texture tex in m_Instance.surfaces[ i ].textures )
                        if( tex == tmpTex )
                            return i;
            }

            // Get Object Material if TerrainTexture == null
            Material tmpMat = GetMaterialByHit( hit );
            if( tmpMat == null )
                return negativeIndex;

            for( int i = 0; i < GetCount; i++ )            
                foreach( Material mat in m_Instance.surfaces[ i ].materials )                
                    if( mat == tmpMat )                    
                        return i;

            return negativeIndex;
        }

        // Get Material ByHit
        public static Material GetMaterialByHit( RaycastHit hit )
        {
            Collider hitCollider = hit.collider;
            if( hitCollider == null || hitCollider.isTrigger )
                return null;

            Renderer tmpRenderer = hitCollider.GetComponent<Renderer>();
            if( tmpRenderer != null )
            {
                MeshCollider meshCollider = hitCollider.GetComponent<MeshCollider>();
                if( meshCollider != null && !meshCollider.convex )
                {
                    Mesh sharedMesh = meshCollider.sharedMesh;
                    int tIndex = hit.triangleIndex * 3;
                    int index1 = sharedMesh.triangles[ tIndex ];
                    int index2 = sharedMesh.triangles[ tIndex + 1 ];
                    int index3 = sharedMesh.triangles[ tIndex + 2 ];
                    int subMeshCount = sharedMesh.subMeshCount;

                    int[] triangles = null;

                    for( int i = 0; i < subMeshCount; i++ )
                    {
                        triangles = sharedMesh.GetTriangles( i );

                        for( int j = 0; j < triangles.Length; j += 3 )                        
                            if( triangles[ j ] == index1 && triangles[ j + 1 ] == index2 && triangles[ j + 2 ] == index3 )                            
                                return tmpRenderer.sharedMaterials[ i ];
                    }
                }
                else
                {
                    return tmpRenderer.sharedMaterial;
                }
            }

            return null;
        }
        // Get MaterialName ByHit
        public static string GetMaterialNameByHit( RaycastHit hit )
        {
            Material tmpMat = GetMaterialByHit( hit );
            return ( tmpMat != null ) ? tmpMat.name : "Unknown Material";
        }
        
        // Get TerrainTexture ByHit
        public static Texture GetTerrainTextureByHit( RaycastHit hit )
        {
            Collider hitCollider = hit.collider;

            if( hitCollider == null || hitCollider.isTrigger )
                return null;

            Terrain tmpTerrain = hitCollider.GetComponent<Terrain>();
            if( tmpTerrain == null )            
                return null;

            TerrainData terrainData = tmpTerrain.terrainData;
            Vector3 terrainPos = tmpTerrain.transform.position;
            int mapX = Mathf.RoundToInt( ( ( hit.point.x - terrainPos.x ) / terrainData.size.x ) * terrainData.alphamapWidth );
            int mapZ = Mathf.RoundToInt( ( ( hit.point.z - terrainPos.z ) / terrainData.size.z ) * terrainData.alphamapHeight );
            float[,,] splatmapData = terrainData.GetAlphamaps( mapX, mapZ, 1, 1 );   
                     
            for( int i = 0; i < terrainData.splatPrototypes.Length; i++ )            
                if( splatmapData[ 0, 0, i ] > .5f )                
                    return terrainData.splatPrototypes[ i ].texture; 

            return null;
        }
        // Get TerrainTextureName ByHit
        public static string GetTerrainTextureNameByHit( RaycastHit hit )
        {
            Texture tmpTex = GetTerrainTextureByHit( hit );
            return ( tmpTex != null ) ? tmpTex.name : "Unknown Texture";
        }


        // Get Count
        public static int GetCount { get { return m_Instance.surfaces.Length; } }
        // Get Names 
        public static string[] GetNames
        {
            get
            {
                string[]  tmpNames = new string[ GetCount ];

                for( int i = 0; i < GetCount; i++ )
                    tmpNames[ i ] = m_Instance.surfaces[ i ].name;

                return tmpNames;
            }
        }
        //
    }
}