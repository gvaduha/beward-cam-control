# Beward cams configuration utility
[![License](http://img.shields.io/badge/license-mit-blue.svg?style=flat-square)](https://raw.githubusercontent.com/json-iterator/go/master/LICENSE)
[![Build Status](https://travis-ci.org/gvaduha/beward-cam-control.svg?branch=master)](https://travis-ci.org/gvaduha/beward-cam-control)

Read and write configuration parameters to Beward IP cameras

## Supported
* SV series
* BD series

## Examples:
Read from camera to file
```
  ./beward-cam-control -h svcam1 -u admin -p admin -t SV -c VideoGeneral >> vidgen.inf
```
Write from file to camera
```
  cat vidgen.inf | ./beward-cam-control -h svcam1 -u admin -p admin -t SV -c VideoGeneral --set
```
