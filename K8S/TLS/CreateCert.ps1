openssl req \
  -newkey rsa:2048 \
  -nodes \
  -x509 \
  -days 365 \
  -out selfsigned.crt \
  -keyout selfsigned.key \
  -addext "subjectAltName = DNS:personalfinancescool.com"

#kubectl apply -f ../Namespace.yml

kubectl create secret tls tls-secret \
  --cert=selfsigned.crt \
  --key=selfsigned.key \
  -n personalfinances
