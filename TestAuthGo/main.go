package main

import (
	"fmt"

	jose "github.com/dvsekhvalnov/jose2go"
)

func main() {

	var key = "eyJhbGciOiJIUzI1NiJ9.ew0KICAic3ViIjogIjEyMzQ1Njc4OTAiLA0KICAibmFtZSI6ICJBbmlzaCBOYXRkZmRoIiwNCiAgImlhdCI6IDE1MTYyMzkwMjINCn0.AtEJgR2e5PEYJmqL_g-66TtqKctDsph06_ZhP2Rt6GA"
	var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6InNkc2FAeWFob28uY29tIiwiVXNlck5hbWUiOiJlc3NpIn0.33R8tha2b5qaKWMNRpDKKS0Cdjw6GvS9ctoIFwMFSlk"

	var deserialized, data, err = jose.Decode(token, []byte(key))

	fmt.Println(deserialized)
	fmt.Println(data)
	fmt.Println(err)
	fmt.Println("changiz")
}
