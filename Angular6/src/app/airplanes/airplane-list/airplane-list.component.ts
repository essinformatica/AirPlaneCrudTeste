import { Component, OnInit } from '@angular/core';
import { AirplaneService } from 'src/app/shared/airplane.service';
import { Airplane } from 'src/app/shared/airplane.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-airplane-list',
  templateUrl: './airplane-list.component.html',
  styleUrls: ['./airplane-list.component.css']
})
export class AirplaneListComponent implements OnInit {

  constructor(private service : AirplaneService,private toastr : ToastrService) { }

  ngOnInit() {
    this.service.populaAirPlane();
  }
  populaForm(air : Airplane){
    this.service.formData = Object.assign({},air);
  }
  apagarRegistro(id:number){
    if(confirm('Tem certeza que quer excluir?')){
      this.service.apagaAirPlane(id).subscribe(res =>{
        this.service.populaAirPlane()
       });
       this.toastr.warning("Excluído Com sucesso","Exc. AirPlane");
    }
  }
}
