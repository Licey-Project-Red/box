from django.db import models

class DB(models.Model):
    time = models.DateTimeField()
    box_number = models.CharField(max_length=5)
    d1 = models.CharField(max_length=5)
    d2 = models.CharField(max_length=5)
    d3 = models.CharField(max_length=5)
    d4 = models.CharField(max_length=5)
    d5 = models.CharField(max_length=5)
    d6 = models.CharField(max_length=5)


    def __str__(self):
        return str(self.time)
        # +' '+self.d1+' '+self.d2+' '+self.d3+' '+self.d4+' '+self.d5+' '+self.d6