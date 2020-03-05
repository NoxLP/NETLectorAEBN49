# NETLectorAEBN49
Is unlikely that you'll use this if you aren't from Spain, so I used spanish all along the code and will use it here too.

Lector de ficheros que siguen la norma 43 de la AEB. Simplemente crea un nuevo objeto "FicheroAEBN43" usando como parámetro la ruta al fichero en el disco duro, y listo.
Este objeto tiene una lista de objetos "IMovimientoBancario", que a su vez contienen todos los datos exportados del fichero original, tanto en formato "valor" (string para los conceptos, decimal para el importe, etc.) como los objetos del registro original del fichero.

Hice esto rápido por que me hacía falta para un pequeño proyecto, así que está hecho siguiendo las directrices contenidas en el documento público de la AEB que encontré en internet: "Serie normas y procedimientos bancarios nº 43", versión junio 2012, circular 1767.

Faltan muchos códigos ISO de divisas (ver enum "DivisasISOEnum", solo incluí las más típicas) y solo funciona con los registros y conceptos comúnes a todos los bancos (igualmente, ver enums "CodigoRegistroEnum" y "ConceptosComunesEnum"), pero no debería ser difícil expandir ambas cosas: la mayoría de la información necesaria es pública y está disponible directamente buscando en google.

Hay unas cuantas excepciones custom y poco más.
