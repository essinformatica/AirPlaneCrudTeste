import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AirplaneService } from 'src/app/shared/airplane.service';
import { ToastrService } from 'ngx-toastr';
import { NullAstVisitor } from '@angular/compiler';

@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styles: []
})
export class AirplaneComponent implements OnInit {
  [x: string]: any;

  constructor(private service :AirplaneService,private toastr : ToastrService) { }
  
  ngOnInit() {
    this.resetForm();
  }
  resetForm(form? :NgForm){
    if(form!=null)
      form.form.reset();
   
    this.service.formData={
    id:0,
    modelo:'' ,
    qtdPassageiros: null,
    dtaCriacao:null
  }
  }
  onSubmit(form : NgForm){
    if(this.service.formData.id == 0)
      this.inserir(form);
    else
      this.atualizar(form);
  }
  inserir(form : NgForm){
     this.service.PostAirPlane(form.value).subscribe(res =>{
     this.toastr.success("Inserido Com sucesso","Cad. AirPlane");
     this.service.populaAirPlane();
     this.resetForm(form);
   });
  }
  atualizar(form : NgForm){
      this.service.PutAirPlane(form.value).subscribe(res =>{
      this.toastr.info("Atualizado Com sucesso","Atual. AirPlane");
      this.service.populaAirPlane();
      this.resetForm(form);
    });
   }
}
