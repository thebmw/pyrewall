#!/bin/bash

BASE_VERSION=`cat ./VERSION`

if [ -z $CI ]; then
  echo "We currently don't support building outside of CI Pipeline"
  exit 1
fi

export VERSION=${BASE_VERSION}.${CI_PIPELINE_IID}