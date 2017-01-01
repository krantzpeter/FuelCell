xof 0303txt 0032


template VertexDuplicationIndices { 
 <b8d65549-d7c9-4995-89cf-53a9a8b031e3>
 DWORD nIndices;
 DWORD nOriginalVertices;
 array DWORD indices[nIndices];
}
template XSkinMeshHeader {
 <3cf169ce-ff7c-44ab-93c0-f78f62d172e2>
 WORD nMaxSkinWeightsPerVertex;
 WORD nMaxSkinWeightsPerFace;
 WORD nBones;
}
template SkinWeights {
 <6f0d123b-bad2-4167-a0d0-80224f25fabb>
 STRING transformNodeName;
 DWORD nWeights;
 array DWORD vertexIndices[nWeights];
 array float weights[nWeights];
 Matrix4x4 matrixOffset;
}

Frame RootFrame {

  FrameTransformMatrix {
    1.000000,0.000000,0.000000,0.000000,
    0.000000,1.000000,0.000000,0.000000,
    0.000000,0.000000,-1.000000,0.000000,
    0.000000,0.000000,0.000000,1.000000;;
  }
  Frame Mesh {

    FrameTransformMatrix {
      1.000000,0.000000,0.000000,0.000000,
      0.000000,1.000000,0.000000,0.000000,
      0.000000,0.000000,1.000000,0.000000,
      0.000000,0.000000,0.000000,1.000000;;
    }
Mesh {
360;
0.800000; 0.000000; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.760800; -0.247200; 1.200000;,
0.800000; 0.000000; 1.200000;,
0.760800; -0.247200; 1.200000;,
0.480000; 0.000000; 0.786900;,
0.480000; 0.000000; 0.786900;,
0.760800; -0.247200; 1.200000;,
0.456500; -0.128200; 0.786900;,
0.760800; -0.247200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.647200; -0.470200; 1.200000;,
0.760800; -0.247200; 1.200000;,
0.388300; -0.243800; 0.786900;,
0.456500; -0.128200; 0.786900;,
0.760800; -0.247200; 1.200000;,
0.647200; -0.470200; 1.200000;,
0.388300; -0.243800; 0.786900;,
0.647200; -0.470200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.470200; -0.647200; 1.200000;,
0.647200; -0.470200; 1.200000;,
0.470200; -0.647200; 1.200000;,
0.388300; -0.243800; 0.786900;,
0.388300; -0.243800; 0.786900;,
0.470200; -0.647200; 1.200000;,
0.282100; -0.335600; 0.786900;,
0.470200; -0.647200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.247200; -0.760800; 1.200000;,
0.470200; -0.647200; 1.200000;,
0.148300; -0.394600; 0.786900;,
0.282100; -0.335600; 0.786900;,
0.470200; -0.647200; 1.200000;,
0.247200; -0.760800; 1.200000;,
0.148300; -0.394600; 0.786900;,
0.247200; -0.760800; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.000000; -0.800000; 1.200000;,
0.247200; -0.760800; 1.200000;,
0.000000; -0.800000; 1.200000;,
0.148300; -0.394600; 0.786900;,
0.148300; -0.394600; 0.786900;,
0.000000; -0.800000; 1.200000;,
0.000000; -0.414900; 0.786900;,
0.000000; -0.800000; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.247200; -0.760800; 1.200000;,
0.000000; -0.800000; 1.200000;,
-0.148300; -0.394600; 0.786900;,
0.000000; -0.414900; 0.786900;,
0.000000; -0.800000; 1.200000;,
-0.247200; -0.760800; 1.200000;,
-0.148300; -0.394600; 0.786900;,
-0.247200; -0.760800; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.470200; -0.647200; 1.200000;,
-0.247200; -0.760800; 1.200000;,
-0.470200; -0.647200; 1.200000;,
-0.148300; -0.394600; 0.786900;,
-0.148300; -0.394600; 0.786900;,
-0.470200; -0.647200; 1.200000;,
-0.282100; -0.335600; 0.786900;,
-0.470200; -0.647200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.647200; -0.470200; 1.200000;,
-0.470200; -0.647200; 1.200000;,
-0.388300; -0.243800; 0.786900;,
-0.282100; -0.335600; 0.786900;,
-0.470200; -0.647200; 1.200000;,
-0.647200; -0.470200; 1.200000;,
-0.388300; -0.243800; 0.786900;,
-0.647200; -0.470200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.760800; -0.247200; 1.200000;,
-0.647200; -0.470200; 1.200000;,
-0.760800; -0.247200; 1.200000;,
-0.388300; -0.243800; 0.786900;,
-0.388300; -0.243800; 0.786900;,
-0.760800; -0.247200; 1.200000;,
-0.456500; -0.128200; 0.786900;,
-0.760800; -0.247200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.800000; 0.000000; 1.200000;,
-0.760800; -0.247200; 1.200000;,
-0.480000; 0.000000; 0.786900;,
-0.456500; -0.128200; 0.786900;,
-0.760800; -0.247200; 1.200000;,
-0.800000; 0.000000; 1.200000;,
-0.480000; 0.000000; 0.786900;,
-0.800000; 0.000000; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.760800; 0.247200; 1.200000;,
-0.800000; 0.000000; 1.200000;,
-0.760800; 0.247200; 1.200000;,
-0.480000; 0.000000; 0.786900;,
-0.480000; 0.000000; 0.786900;,
-0.760800; 0.247200; 1.200000;,
-0.456500; 0.128200; 0.786900;,
-0.760800; 0.247200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.647200; 0.470200; 1.200000;,
-0.760800; 0.247200; 1.200000;,
-0.388300; 0.243800; 0.786900;,
-0.456500; 0.128200; 0.786900;,
-0.760800; 0.247200; 1.200000;,
-0.647200; 0.470200; 1.200000;,
-0.388300; 0.243800; 0.786900;,
-0.647200; 0.470200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.470200; 0.647200; 1.200000;,
-0.647200; 0.470200; 1.200000;,
-0.470200; 0.647200; 1.200000;,
-0.388300; 0.243800; 0.786900;,
-0.388300; 0.243800; 0.786900;,
-0.470200; 0.647200; 1.200000;,
-0.282100; 0.335600; 0.786900;,
-0.470200; 0.647200; 1.200000;,
0.000000; 0.000000; 1.200000;,
-0.247200; 0.760800; 1.200000;,
-0.470200; 0.647200; 1.200000;,
-0.148300; 0.394600; 0.786900;,
-0.282100; 0.335600; 0.786900;,
-0.470200; 0.647200; 1.200000;,
-0.247200; 0.760800; 1.200000;,
-0.148300; 0.394600; 0.786900;,
-0.247200; 0.760800; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.000000; 0.800000; 1.200000;,
-0.247200; 0.760800; 1.200000;,
0.000000; 0.800000; 1.200000;,
-0.148300; 0.394600; 0.786900;,
-0.148300; 0.394600; 0.786900;,
0.000000; 0.800000; 1.200000;,
0.000000; 0.414900; 0.786900;,
0.000000; 0.800000; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.247200; 0.760800; 1.200000;,
0.000000; 0.800000; 1.200000;,
0.148300; 0.394600; 0.786900;,
0.000000; 0.414900; 0.786900;,
0.000000; 0.800000; 1.200000;,
0.247200; 0.760800; 1.200000;,
0.148300; 0.394600; 0.786900;,
0.247200; 0.760800; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.470200; 0.647200; 1.200000;,
0.247200; 0.760800; 1.200000;,
0.470200; 0.647200; 1.200000;,
0.148300; 0.394600; 0.786900;,
0.148300; 0.394600; 0.786900;,
0.470200; 0.647200; 1.200000;,
0.282100; 0.335600; 0.786900;,
0.470200; 0.647200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.647200; 0.470200; 1.200000;,
0.470200; 0.647200; 1.200000;,
0.388300; 0.243800; 0.786900;,
0.282100; 0.335600; 0.786900;,
0.470200; 0.647200; 1.200000;,
0.647200; 0.470200; 1.200000;,
0.388300; 0.243800; 0.786900;,
0.647200; 0.470200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.760800; 0.247200; 1.200000;,
0.647200; 0.470200; 1.200000;,
0.760800; 0.247200; 1.200000;,
0.388300; 0.243800; 0.786900;,
0.388300; 0.243800; 0.786900;,
0.760800; 0.247200; 1.200000;,
0.456500; 0.128200; 0.786900;,
0.760800; 0.247200; 1.200000;,
0.000000; 0.000000; 1.200000;,
0.800000; 0.000000; 1.200000;,
0.760800; 0.247200; 1.200000;,
0.480000; 0.000000; 0.786900;,
0.456500; 0.128200; 0.786900;,
0.760800; 0.247200; 1.200000;,
0.800000; 0.000000; 1.200000;,
0.480000; 0.000000; 0.786900;,
0.480000; 0.000000; 0.786900;,
0.456500; -0.128200; -0.786900;,
0.480000; 0.000000; -0.786900;,
0.480000; 0.000000; 0.786900;,
0.456500; -0.128200; 0.786900;,
0.456500; -0.128200; -0.786900;,
0.456500; -0.128200; 0.786900;,
0.388300; -0.243800; 0.786900;,
0.456500; -0.128200; -0.786900;,
0.456500; -0.128200; -0.786900;,
0.388300; -0.243800; 0.786900;,
0.388300; -0.243800; -0.786900;,
0.388300; -0.243800; 0.786900;,
0.282100; -0.335600; -0.786900;,
0.388300; -0.243800; -0.786900;,
0.388300; -0.243800; 0.786900;,
0.282100; -0.335600; 0.786900;,
0.282100; -0.335600; -0.786900;,
0.282100; -0.335600; 0.786900;,
0.148300; -0.394600; 0.786900;,
0.282100; -0.335600; -0.786900;,
0.282100; -0.335600; -0.786900;,
0.148300; -0.394600; 0.786900;,
0.148300; -0.394600; -0.786900;,
0.148300; -0.394600; 0.786900;,
0.000000; -0.414900; -0.786900;,
0.148300; -0.394600; -0.786900;,
0.148300; -0.394600; 0.786900;,
0.000000; -0.414900; 0.786900;,
0.000000; -0.414900; -0.786900;,
0.000000; -0.414900; 0.786900;,
-0.148300; -0.394600; 0.786900;,
0.000000; -0.414900; -0.786900;,
0.000000; -0.414900; -0.786900;,
-0.148300; -0.394600; 0.786900;,
-0.148300; -0.394600; -0.786900;,
-0.148300; -0.394600; 0.786900;,
-0.282100; -0.335600; -0.786900;,
-0.148300; -0.394600; -0.786900;,
-0.148300; -0.394600; 0.786900;,
-0.282100; -0.335600; 0.786900;,
-0.282100; -0.335600; -0.786900;,
-0.282100; -0.335600; 0.786900;,
-0.388300; -0.243800; 0.786900;,
-0.282100; -0.335600; -0.786900;,
-0.282100; -0.335600; -0.786900;,
-0.388300; -0.243800; 0.786900;,
-0.388300; -0.243800; -0.786900;,
-0.388300; -0.243800; 0.786900;,
-0.456500; -0.128200; -0.786900;,
-0.388300; -0.243800; -0.786900;,
-0.388300; -0.243800; 0.786900;,
-0.456500; -0.128200; 0.786900;,
-0.456500; -0.128200; -0.786900;,
-0.456500; -0.128200; 0.786900;,
-0.480000; 0.000000; 0.786900;,
-0.456500; -0.128200; -0.786900;,
-0.456500; -0.128200; -0.786900;,
-0.480000; 0.000000; 0.786900;,
-0.480000; 0.000000; -0.786900;,
-0.480000; 0.000000; 0.786900;,
-0.456500; 0.128200; -0.786900;,
-0.480000; 0.000000; -0.786900;,
-0.480000; 0.000000; 0.786900;,
-0.456500; 0.128200; 0.786900;,
-0.456500; 0.128200; -0.786900;,
-0.456500; 0.128200; 0.786900;,
-0.388300; 0.243800; 0.786900;,
-0.456500; 0.128200; -0.786900;,
-0.456500; 0.128200; -0.786900;,
-0.388300; 0.243800; 0.786900;,
-0.388300; 0.243800; -0.786900;,
-0.388300; 0.243800; 0.786900;,
-0.282100; 0.335600; -0.786900;,
-0.388300; 0.243800; -0.786900;,
-0.388300; 0.243800; 0.786900;,
-0.282100; 0.335600; 0.786900;,
-0.282100; 0.335600; -0.786900;,
-0.282100; 0.335600; 0.786900;,
-0.148300; 0.394600; 0.786900;,
-0.282100; 0.335600; -0.786900;,
-0.282100; 0.335600; -0.786900;,
-0.148300; 0.394600; 0.786900;,
-0.148300; 0.394600; -0.786900;,
-0.148300; 0.394600; 0.786900;,
0.000000; 0.414900; -0.786900;,
-0.148300; 0.394600; -0.786900;,
-0.148300; 0.394600; 0.786900;,
0.000000; 0.414900; 0.786900;,
0.000000; 0.414900; -0.786900;,
0.000000; 0.414900; 0.786900;,
0.148300; 0.394600; 0.786900;,
0.000000; 0.414900; -0.786900;,
0.000000; 0.414900; -0.786900;,
0.148300; 0.394600; 0.786900;,
0.148300; 0.394600; -0.786900;,
0.148300; 0.394600; 0.786900;,
0.282100; 0.335600; -0.786900;,
0.148300; 0.394600; -0.786900;,
0.148300; 0.394600; 0.786900;,
0.282100; 0.335600; 0.786900;,
0.282100; 0.335600; -0.786900;,
0.282100; 0.335600; 0.786900;,
0.388300; 0.243800; 0.786900;,
0.282100; 0.335600; -0.786900;,
0.282100; 0.335600; -0.786900;,
0.388300; 0.243800; 0.786900;,
0.388300; 0.243800; -0.786900;,
0.388300; 0.243800; 0.786900;,
0.456500; 0.128200; -0.786900;,
0.388300; 0.243800; -0.786900;,
0.388300; 0.243800; 0.786900;,
0.456500; 0.128200; 0.786900;,
0.456500; 0.128200; -0.786900;,
0.456500; 0.128200; 0.786900;,
0.480000; 0.000000; 0.786900;,
0.456500; 0.128200; -0.786900;,
0.456500; 0.128200; -0.786900;,
0.480000; 0.000000; 0.786900;,
0.480000; 0.000000; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.148300; 0.394600; -0.786900;,
0.000000; 0.414900; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.000000; 0.414900; -0.786900;,
-0.148300; 0.394600; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.148300; 0.394600; -0.786900;,
-0.282100; 0.335600; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.282100; 0.335600; -0.786900;,
-0.388300; 0.243800; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.456500; 0.128200; -0.786900;,
-0.388300; 0.243800; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.480000; 0.000000; -0.786900;,
-0.456500; 0.128200; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.456500; -0.128200; -0.786900;,
-0.480000; 0.000000; -0.786900;,
0.000000; 0.000000; -1.200000;,
-0.388300; -0.243800; -0.786900;,
-0.456500; -0.128200; -0.786900;,
-0.282100; -0.335600; -0.786900;,
-0.388300; -0.243800; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.000000; 0.000000; -1.200000;,
-0.148300; -0.394600; -0.786900;,
-0.282100; -0.335600; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.000000; -0.414900; -0.786900;,
-0.148300; -0.394600; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.148300; -0.394600; -0.786900;,
0.000000; -0.414900; -0.786900;,
0.282100; -0.335600; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.148300; -0.394600; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.388300; -0.243800; -0.786900;,
0.282100; -0.335600; -0.786900;,
0.456500; -0.128200; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.388300; -0.243800; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.480000; 0.000000; -0.786900;,
0.456500; -0.128200; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.480000; 0.000000; -0.786900;,
0.456500; 0.128200; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.456500; 0.128200; -0.786900;,
0.388300; 0.243800; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.388300; 0.243800; -0.786900;,
0.282100; 0.335600; -0.786900;,
0.000000; 0.000000; -1.200000;,
0.282100; 0.335600; -0.786900;,
0.148300; 0.394600; -0.786900;;
120;
3; 0, 2, 1;,
3; 3, 5, 4;,
3; 6, 8, 7;,
3; 9, 11, 10;,
3; 12, 14, 13;,
3; 15, 17, 16;,
3; 18, 20, 19;,
3; 21, 23, 22;,
3; 24, 26, 25;,
3; 27, 29, 28;,
3; 30, 32, 31;,
3; 33, 35, 34;,
3; 36, 38, 37;,
3; 39, 41, 40;,
3; 42, 44, 43;,
3; 45, 47, 46;,
3; 48, 50, 49;,
3; 51, 53, 52;,
3; 54, 56, 55;,
3; 57, 59, 58;,
3; 60, 62, 61;,
3; 63, 65, 64;,
3; 66, 68, 67;,
3; 69, 71, 70;,
3; 72, 74, 73;,
3; 75, 77, 76;,
3; 78, 80, 79;,
3; 81, 83, 82;,
3; 84, 86, 85;,
3; 87, 89, 88;,
3; 90, 92, 91;,
3; 93, 95, 94;,
3; 96, 98, 97;,
3; 99, 101, 100;,
3; 102, 104, 103;,
3; 105, 107, 106;,
3; 108, 110, 109;,
3; 111, 113, 112;,
3; 114, 116, 115;,
3; 117, 119, 118;,
3; 120, 122, 121;,
3; 123, 125, 124;,
3; 126, 128, 127;,
3; 129, 131, 130;,
3; 132, 134, 133;,
3; 135, 137, 136;,
3; 138, 140, 139;,
3; 141, 143, 142;,
3; 144, 146, 145;,
3; 147, 149, 148;,
3; 150, 152, 151;,
3; 153, 155, 154;,
3; 156, 158, 157;,
3; 159, 161, 160;,
3; 162, 164, 163;,
3; 165, 167, 166;,
3; 168, 170, 169;,
3; 171, 173, 172;,
3; 174, 176, 175;,
3; 177, 179, 178;,
3; 180, 182, 181;,
3; 183, 185, 184;,
3; 186, 188, 187;,
3; 189, 191, 190;,
3; 192, 194, 193;,
3; 195, 197, 196;,
3; 198, 200, 199;,
3; 201, 203, 202;,
3; 204, 206, 205;,
3; 207, 209, 208;,
3; 210, 212, 211;,
3; 213, 215, 214;,
3; 216, 218, 217;,
3; 219, 221, 220;,
3; 222, 224, 223;,
3; 225, 227, 226;,
3; 228, 230, 229;,
3; 231, 233, 232;,
3; 234, 236, 235;,
3; 237, 239, 238;,
3; 240, 242, 241;,
3; 243, 245, 244;,
3; 246, 248, 247;,
3; 249, 251, 250;,
3; 252, 254, 253;,
3; 255, 257, 256;,
3; 258, 260, 259;,
3; 261, 263, 262;,
3; 264, 266, 265;,
3; 267, 269, 268;,
3; 270, 272, 271;,
3; 273, 275, 274;,
3; 276, 278, 277;,
3; 279, 281, 280;,
3; 282, 284, 283;,
3; 285, 287, 286;,
3; 288, 290, 289;,
3; 291, 293, 292;,
3; 294, 296, 295;,
3; 297, 299, 298;,
3; 300, 302, 301;,
3; 303, 305, 304;,
3; 306, 308, 307;,
3; 309, 311, 310;,
3; 312, 314, 313;,
3; 315, 317, 316;,
3; 318, 320, 319;,
3; 321, 323, 322;,
3; 324, 326, 325;,
3; 327, 329, 328;,
3; 330, 332, 331;,
3; 333, 335, 334;,
3; 336, 338, 337;,
3; 339, 341, 340;,
3; 342, 344, 343;,
3; 345, 347, 346;,
3; 348, 350, 349;,
3; 351, 353, 352;,
3; 354, 356, 355;,
3; 357, 359, 358;;
  MeshMaterialList {
    3;
    120;
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    2,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1;;
  Material Material_001 {
    1.000000; 1.000000; 1.000000;1.0;;
    0.500000;
    1.000000; 1.000000; 1.000000;;
    0.0; 0.0; 0.0;;
  }  //End of Material
  Material Material_002 {
    1.000000; 1.000000; 1.000000;1.0;;
    0.500000;
    1.000000; 1.000000; 1.000000;;
    0.0; 0.0; 0.0;;
  }  //End of Material
  Material Mat1 {
    1.0; 1.0; 1.0; 1.0;;
    1.0;
    1.0; 1.0; 1.0;;
    0.0; 0.0; 0.0;;
  TextureFilename {    "FUELCELL.JPG";  }
  }  // End of Material
    }  //End of MeshMaterialList
  MeshNormals {
360;
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.784387; -0.124363; -0.607624;,
    0.784387; -0.124363; -0.607624;,
    0.784387; -0.124363; -0.607624;,
    0.776879; -0.142399; -0.613300;,
    0.776879; -0.142399; -0.613300;,
    0.776879; -0.142399; -0.613300;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.678854; -0.400494; -0.615406;,
    0.678854; -0.400494; -0.615406;,
    0.678854; -0.400494; -0.615406;,
    0.693319; -0.353191; -0.628101;,
    0.693319; -0.353191; -0.628101;,
    0.693319; -0.353191; -0.628101;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.543901; -0.543901; -0.638966;,
    0.543901; -0.543901; -0.638966;,
    0.543901; -0.543901; -0.638966;,
    0.493728; -0.571184; -0.655660;,
    0.493728; -0.571184; -0.655660;,
    0.493728; -0.571184; -0.655660;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.303781; -0.688955; -0.658010;,
    0.303781; -0.688955; -0.658010;,
    0.303781; -0.688955; -0.658010;,
    0.337626; -0.662770; -0.668355;,
    0.337626; -0.662770; -0.668355;,
    0.337626; -0.662770; -0.668355;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.115635; -0.729362; -0.674245;,
    0.115635; -0.729362; -0.674245;,
    0.115635; -0.729362; -0.674245;,
    0.099612; -0.727805; -0.678487;,
    0.099612; -0.727805; -0.678487;,
    0.099612; -0.727805; -0.678487;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.099612; -0.727805; -0.678487;,
    -0.099612; -0.727805; -0.678487;,
    -0.099612; -0.727805; -0.678487;,
    -0.115635; -0.729362; -0.674245;,
    -0.115635; -0.729362; -0.674245;,
    -0.115635; -0.729362; -0.674245;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.337626; -0.662770; -0.668355;,
    -0.337626; -0.662770; -0.668355;,
    -0.337626; -0.662770; -0.668355;,
    -0.303781; -0.688955; -0.658010;,
    -0.303781; -0.688955; -0.658010;,
    -0.303781; -0.688955; -0.658010;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.493728; -0.571184; -0.655660;,
    -0.493728; -0.571184; -0.655660;,
    -0.493728; -0.571184; -0.655660;,
    -0.543901; -0.543901; -0.638966;,
    -0.543901; -0.543901; -0.638966;,
    -0.543901; -0.543901; -0.638966;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.693319; -0.353191; -0.628101;,
    -0.693319; -0.353191; -0.628101;,
    -0.693319; -0.353191; -0.628101;,
    -0.678854; -0.400494; -0.615406;,
    -0.678854; -0.400494; -0.615406;,
    -0.678854; -0.400494; -0.615406;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.776879; -0.142399; -0.613300;,
    -0.776879; -0.142399; -0.613300;,
    -0.776879; -0.142399; -0.613300;,
    -0.784387; -0.124363; -0.607624;,
    -0.784387; -0.124363; -0.607624;,
    -0.784387; -0.124363; -0.607624;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.784387; 0.124363; -0.607624;,
    -0.784387; 0.124363; -0.607624;,
    -0.784387; 0.124363; -0.607624;,
    -0.776879; 0.142399; -0.613300;,
    -0.776879; 0.142399; -0.613300;,
    -0.776879; 0.142399; -0.613300;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.678854; 0.400494; -0.615406;,
    -0.678854; 0.400494; -0.615406;,
    -0.678854; 0.400494; -0.615406;,
    -0.693319; 0.353191; -0.628101;,
    -0.693319; 0.353191; -0.628101;,
    -0.693319; 0.353191; -0.628101;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.543901; 0.543901; -0.638966;,
    -0.543901; 0.543901; -0.638966;,
    -0.543901; 0.543901; -0.638966;,
    -0.493728; 0.571184; -0.655660;,
    -0.493728; 0.571184; -0.655660;,
    -0.493728; 0.571184; -0.655660;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.303781; 0.688955; -0.658010;,
    -0.303781; 0.688955; -0.658010;,
    -0.303781; 0.688955; -0.658010;,
    -0.337626; 0.662770; -0.668355;,
    -0.337626; 0.662770; -0.668355;,
    -0.337626; 0.662770; -0.668355;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    -0.115635; 0.729362; -0.674245;,
    -0.115635; 0.729362; -0.674245;,
    -0.115635; 0.729362; -0.674245;,
    -0.099612; 0.727805; -0.678487;,
    -0.099612; 0.727805; -0.678487;,
    -0.099612; 0.727805; -0.678487;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.099612; 0.727805; -0.678487;,
    0.099612; 0.727805; -0.678487;,
    0.099612; 0.727805; -0.678487;,
    0.115635; 0.729362; -0.674245;,
    0.115635; 0.729362; -0.674245;,
    0.115635; 0.729362; -0.674245;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.337626; 0.662770; -0.668355;,
    0.337626; 0.662770; -0.668355;,
    0.337626; 0.662770; -0.668355;,
    0.303781; 0.688955; -0.658010;,
    0.303781; 0.688955; -0.658010;,
    0.303781; 0.688955; -0.658010;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.493728; 0.571184; -0.655660;,
    0.493728; 0.571184; -0.655660;,
    0.493728; 0.571184; -0.655660;,
    0.543901; 0.543901; -0.638966;,
    0.543901; 0.543901; -0.638966;,
    0.543901; 0.543901; -0.638966;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.693319; 0.353191; -0.628101;,
    0.693319; 0.353191; -0.628101;,
    0.693319; 0.353191; -0.628101;,
    0.678854; 0.400494; -0.615406;,
    0.678854; 0.400494; -0.615406;,
    0.678854; 0.400494; -0.615406;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.000000; 0.000000; 1.000000;,
    0.776879; 0.142399; -0.613300;,
    0.776879; 0.142399; -0.613300;,
    0.776879; 0.142399; -0.613300;,
    0.784387; 0.124363; -0.607624;,
    0.784387; 0.124363; -0.607624;,
    0.784387; 0.124363; -0.607624;,
    0.983581; -0.180273; 0.000000;,
    0.895688; -0.164159; -0.413221;,
    0.895688; -0.164159; -0.413221;,
    0.983581; -0.180273; 0.000000;,
    0.983581; -0.180273; 0.000000;,
    0.983581; -0.180273; 0.000000;,
    0.861263; -0.508103; 0.000000;,
    0.861263; -0.508103; 0.000000;,
    0.861263; -0.508103; 0.000000;,
    0.861263; -0.508103; 0.000000;,
    0.861263; -0.508103; 0.000000;,
    0.350108; -0.206549; 0.913633;,
    0.653951; -0.756523; 0.000000;,
    0.600391; -0.694571; -0.396344;,
    0.600391; -0.694571; -0.396344;,
    0.653951; -0.756523; 0.000000;,
    0.653951; -0.756523; 0.000000;,
    0.653951; -0.756523; 0.000000;,
    0.403455; -0.914975; 0.000000;,
    0.403455; -0.914975; 0.000000;,
    0.403455; -0.914975; 0.000000;,
    0.403455; -0.914975; 0.000000;,
    0.403455; -0.914975; 0.000000;,
    0.156133; -0.354076; 0.922056;,
    0.135594; -0.990753; 0.000000;,
    0.048708; -0.860622; -0.506851;,
    0.125340; -0.915799; -0.381542;,
    0.135594; -0.990753; 0.000000;,
    0.135594; -0.990753; 0.000000;,
    0.135594; -0.990753; 0.000000;,
    -0.135594; -0.990753; 0.000000;,
    -0.135594; -0.990753; 0.000000;,
    -0.135594; -0.990753; 0.000000;,
    -0.135594; -0.990753; 0.000000;,
    -0.135594; -0.990753; 0.000000;,
    -0.125340; -0.915799; -0.381542;,
    -0.403455; -0.914975; 0.000000;,
    -0.372021; -0.843684; -0.386975;,
    -0.372021; -0.843684; -0.386975;,
    -0.403455; -0.914975; 0.000000;,
    -0.403455; -0.914975; 0.000000;,
    -0.403455; -0.914975; 0.000000;,
    -0.653951; -0.756523; 0.000000;,
    -0.653951; -0.756523; 0.000000;,
    -0.653951; -0.756523; 0.000000;,
    -0.653951; -0.756523; 0.000000;,
    -0.653951; -0.756523; 0.000000;,
    -0.609363; -0.586322; -0.533708;,
    -0.861263; -0.508103; 0.000000;,
    -0.760460; -0.352611; -0.545244;,
    -0.861263; -0.508103; 0.000000;,
    -0.861263; -0.508103; 0.000000;,
    -0.861263; -0.508103; 0.000000;,
    -0.861263; -0.508103; 0.000000;,
    -0.983581; -0.180273; 0.000000;,
    -0.983581; -0.180273; 0.000000;,
    -0.983581; -0.180273; 0.000000;,
    -0.983581; -0.180273; 0.000000;,
    -0.983581; -0.180273; 0.000000;,
    -0.832606; -0.065859; -0.549883;,
    -0.983581; 0.180273; 0.000000;,
    -0.895688; 0.164159; -0.413221;,
    -0.983581; 0.180273; 0.000000;,
    -0.983581; 0.180273; 0.000000;,
    -0.983581; 0.180273; 0.000000;,
    -0.983581; 0.180273; 0.000000;,
    -0.861263; 0.508103; 0.000000;,
    -0.861263; 0.508103; 0.000000;,
    -0.861263; 0.508103; 0.000000;,
    -0.861263; 0.508103; 0.000000;,
    -0.861263; 0.508103; 0.000000;,
    -0.493301; -0.012787; 0.869747;,
    -0.653951; 0.756523; 0.000000;,
    -0.456862; 0.142216; 0.878079;,
    -0.653951; 0.756523; 0.000000;,
    -0.653951; 0.756523; 0.000000;,
    -0.653951; 0.756523; 0.000000;,
    -0.653951; 0.756523; 0.000000;,
    -0.403455; 0.914975; 0.000000;,
    -0.403455; 0.914975; 0.000000;,
    -0.403455; 0.914975; 0.000000;,
    -0.403455; 0.914975; 0.000000;,
    -0.403455; 0.914975; 0.000000;,
    -0.384991; 0.266427; 0.883602;,
    -0.135594; 0.990753; 0.000000;,
    -0.290933; 0.362133; 0.885525;,
    -0.135594; 0.990753; 0.000000;,
    -0.135594; 0.990753; 0.000000;,
    -0.135594; 0.990753; 0.000000;,
    -0.135594; 0.990753; 0.000000;,
    0.135594; 0.990753; 0.000000;,
    0.135594; 0.990753; 0.000000;,
    0.135594; 0.990753; 0.000000;,
    0.135594; 0.990753; 0.000000;,
    0.135594; 0.990753; 0.000000;,
    -0.181860; 0.432783; 0.882931;,
    0.403455; 0.914975; 0.000000;,
    -0.054231; 0.477371; 0.877010;,
    0.403455; 0.914975; 0.000000;,
    0.403455; 0.914975; 0.000000;,
    0.403455; 0.914975; 0.000000;,
    0.403455; 0.914975; 0.000000;,
    0.653951; 0.756523; 0.000000;,
    0.653951; 0.756523; 0.000000;,
    0.653951; 0.756523; 0.000000;,
    0.653951; 0.756523; 0.000000;,
    0.653951; 0.756523; 0.000000;,
    0.090396; 0.486923; 0.868740;,
    0.861263; 0.508103; 0.000000;,
    0.244392; 0.445601; 0.861202;,
    0.861263; 0.508103; 0.000000;,
    0.861263; 0.508103; 0.000000;,
    0.861263; 0.508103; 0.000000;,
    0.861263; 0.508103; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    0.983581; 0.180273; 0.000000;,
    -0.545366; -0.838099; -0.010163;,
    -0.096133; -0.702292; 0.705344;,
    -0.290933; 0.362133; 0.885525;,
    -0.545366; -0.838099; -0.010163;,
    0.096133; -0.702292; 0.705344;,
    -0.384991; 0.266427; 0.883602;,
    -0.545366; -0.838099; -0.010163;,
    0.282601; -0.640919; 0.713675;,
    -0.456862; 0.142216; 0.878079;,
    -0.545366; -0.838099; -0.010163;,
    0.448469; -0.518815; 0.727744;,
    -0.493301; -0.012787; 0.869747;,
    -0.545366; -0.838099; -0.010163;,
    -0.576617; 0.340190; -0.742790;,
    -0.576617; 0.340190; -0.742790;,
    -0.545366; -0.838099; -0.010163;,
    -0.832606; -0.065859; -0.549883;,
    -0.895688; 0.164159; -0.413221;,
    -0.545366; -0.838099; -0.010163;,
    -0.760460; -0.352611; -0.545244;,
    -0.832606; -0.065859; -0.549883;,
    -0.545366; -0.838099; -0.010163;,
    -0.609363; -0.586322; -0.533708;,
    -0.760460; -0.352611; -0.545244;,
    -0.448469; -0.518815; -0.727744;,
    -0.609363; -0.586322; -0.533708;,
    -0.545366; -0.838099; -0.010163;,
    -0.545366; -0.838099; -0.010163;,
    -0.372021; -0.843684; -0.386975;,
    -0.372021; -0.843684; -0.386975;,
    -0.545366; -0.838099; -0.010163;,
    0.048708; -0.860622; -0.506851;,
    -0.125340; -0.915799; -0.381542;,
    -0.545366; -0.838099; -0.010163;,
    0.125340; -0.915799; -0.381542;,
    0.048708; -0.860622; -0.506851;,
    -0.282601; 0.640919; 0.713675;,
    -0.545366; -0.838099; -0.010163;,
    0.156133; -0.354076; 0.922056;,
    -0.545366; -0.838099; -0.010163;,
    0.600391; -0.694571; -0.396344;,
    0.600391; -0.694571; -0.396344;,
    -0.576617; 0.340190; 0.742790;,
    -0.545366; -0.838099; -0.010163;,
    0.350108; -0.206549; 0.913633;,
    -0.545366; -0.838099; -0.010163;,
    0.895688; -0.164159; -0.413221;,
    0.895688; -0.164159; -0.413221;,
    -0.545366; -0.838099; -0.010163;,
    -0.647694; -0.118717; 0.752586;,
    0.244392; 0.445601; 0.861202;,
    -0.545366; -0.838099; -0.010163;,
    -0.576617; -0.340190; 0.742790;,
    0.090396; 0.486923; 0.868740;,
    -0.545366; -0.838099; -0.010163;,
    -0.448469; -0.518815; 0.727744;,
    -0.054231; 0.477371; 0.877010;,
    -0.545366; -0.838099; -0.010163;,
    -0.282601; -0.640919; 0.713675;,
    -0.181860; 0.432783; 0.882931;;
120;
3; 0, 2, 1;,
3; 3, 5, 4;,
3; 6, 8, 7;,
3; 9, 11, 10;,
3; 12, 14, 13;,
3; 15, 17, 16;,
3; 18, 20, 19;,
3; 21, 23, 22;,
3; 24, 26, 25;,
3; 27, 29, 28;,
3; 30, 32, 31;,
3; 33, 35, 34;,
3; 36, 38, 37;,
3; 39, 41, 40;,
3; 42, 44, 43;,
3; 45, 47, 46;,
3; 48, 50, 49;,
3; 51, 53, 52;,
3; 54, 56, 55;,
3; 57, 59, 58;,
3; 60, 62, 61;,
3; 63, 65, 64;,
3; 66, 68, 67;,
3; 69, 71, 70;,
3; 72, 74, 73;,
3; 75, 77, 76;,
3; 78, 80, 79;,
3; 81, 83, 82;,
3; 84, 86, 85;,
3; 87, 89, 88;,
3; 90, 92, 91;,
3; 93, 95, 94;,
3; 96, 98, 97;,
3; 99, 101, 100;,
3; 102, 104, 103;,
3; 105, 107, 106;,
3; 108, 110, 109;,
3; 111, 113, 112;,
3; 114, 116, 115;,
3; 117, 119, 118;,
3; 120, 122, 121;,
3; 123, 125, 124;,
3; 126, 128, 127;,
3; 129, 131, 130;,
3; 132, 134, 133;,
3; 135, 137, 136;,
3; 138, 140, 139;,
3; 141, 143, 142;,
3; 144, 146, 145;,
3; 147, 149, 148;,
3; 150, 152, 151;,
3; 153, 155, 154;,
3; 156, 158, 157;,
3; 159, 161, 160;,
3; 162, 164, 163;,
3; 165, 167, 166;,
3; 168, 170, 169;,
3; 171, 173, 172;,
3; 174, 176, 175;,
3; 177, 179, 178;,
3; 180, 182, 181;,
3; 183, 185, 184;,
3; 186, 188, 187;,
3; 189, 191, 190;,
3; 192, 194, 193;,
3; 195, 197, 196;,
3; 198, 200, 199;,
3; 201, 203, 202;,
3; 204, 206, 205;,
3; 207, 209, 208;,
3; 210, 212, 211;,
3; 213, 215, 214;,
3; 216, 218, 217;,
3; 219, 221, 220;,
3; 222, 224, 223;,
3; 225, 227, 226;,
3; 228, 230, 229;,
3; 231, 233, 232;,
3; 234, 236, 235;,
3; 237, 239, 238;,
3; 240, 242, 241;,
3; 243, 245, 244;,
3; 246, 248, 247;,
3; 249, 251, 250;,
3; 252, 254, 253;,
3; 255, 257, 256;,
3; 258, 260, 259;,
3; 261, 263, 262;,
3; 264, 266, 265;,
3; 267, 269, 268;,
3; 270, 272, 271;,
3; 273, 275, 274;,
3; 276, 278, 277;,
3; 279, 281, 280;,
3; 282, 284, 283;,
3; 285, 287, 286;,
3; 288, 290, 289;,
3; 291, 293, 292;,
3; 294, 296, 295;,
3; 297, 299, 298;,
3; 300, 302, 301;,
3; 303, 305, 304;,
3; 306, 308, 307;,
3; 309, 311, 310;,
3; 312, 314, 313;,
3; 315, 317, 316;,
3; 318, 320, 319;,
3; 321, 323, 322;,
3; 324, 326, 325;,
3; 327, 329, 328;,
3; 330, 332, 331;,
3; 333, 335, 334;,
3; 336, 338, 337;,
3; 339, 341, 340;,
3; 342, 344, 343;,
3; 345, 347, 346;,
3; 348, 350, 349;,
3; 351, 353, 352;,
3; 354, 356, 355;,
3; 357, 359, 358;;
}  //End of MeshNormals
MeshTextureCoords {
360;
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;0.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-1.000000;,
1.000000;-0.000000;,
0.000000;-0.000000;,
1.000000;-1.000000;,
1.000000;-0.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-1.000000;,
1.000000;-0.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-1.000000;,
1.000000;-0.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-1.000000;,
1.000000;-0.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;,
0.000000;-0.000000;,
1.000000;-0.000000;,
1.000000;-1.000000;;
}  //End of MeshTextureCoords
  }  // End of the Mesh Mesh 
  }  // SI End of the Object Mesh 
}  // End of the Root Frame