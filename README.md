# Beward cams configuration utility
Read and write configuration parameters to Beward IP cameras

## Supported
* SV series
* BD series (postponed)

## Examples:
Read from camera to file
  ./beward-cam-control -h svcam1 -u admin -p admin -t SV -c VideoGeneral >> vidgen.inf
Write from file to camera
  cat vidgen.inf | ./beward-cam-control -h svcam1 -u admin -p admin -t SV -c VideoGeneral --set