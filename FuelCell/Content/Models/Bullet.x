xof 0303txt 0032
template ExporterInfo {
 <523f1a9d-4c72-49a7-8e7d-01f57756dcdc>
 STRING szExporterName;
}

template Frame {
 <3d82ab46-62da-11cf-ab39-0020af71e433>
 [...]
}

template Matrix4x4 {
 <f6f23f45-7686-11cf-8f52-0040333594a3>
 array FLOAT matrix[16];
}

template FrameTransformMatrix {
 <f6f23f41-7686-11cf-8f52-0040333594a3>
 Matrix4x4 frameMatrix;
}


ExporterInfo {
 "trueSpace 7.6 d3dx x file exporter v1.0";
}

Frame DXCC_ROOT {
 

 FrameTransformMatrix {
  1.000000,0.000000,0.000000,0.000000,0.000000,-0.000000,-1.000000,0.000000,0.000000,1.000000,-0.000000,0.000000,0.000000,0.000000,0.000000,1.000000;;
 }
}