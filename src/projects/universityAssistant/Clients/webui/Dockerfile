FROM node:16-alpine as builder
WORKDIR /app/src
COPY /src/projects/universityAssistant/Clients/webui/ ./
#COPY /src/projects/universityAssistant/Clients/webui/package-lock.json ./

RUN npm ci

COPY . .
RUN npm run build

FROM nginx:alpine
COPY /src/projects/universityAssistant/Clients/webui/nginx.conf /etc/nginx/nginx.conf
RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /app/src/build /usr/share/nginx/html
EXPOSE 80 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
