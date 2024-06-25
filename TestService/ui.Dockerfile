# FROM rocksolidknowledge/adminui:dev
# To be build image from scratch (project [AdminUi.csproj] in solution)
# Build FROM sdk
# Publish with Runtime


USER root

COPY ./DbStart.sh /app/DbStart.sh
COPY ./wait-for-it.sh /app/wait-for-it.sh

RUN chmod +x /app/DbStart.sh
RUN chmod +x /app/wait-for-it.sh

USER identityexpress
