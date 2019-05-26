import { Component, OnInit } from '@angular/core';
import { AirplaneService } from '../shared/airplane.service';

@Component({
  selector: 'app-airplanes',
  templateUrl: './airplanes.component.html',
  styleUrls: ['./airplanes.component.css']
})
export class AirplanesComponent implements OnInit {

  constructor(private service : AirplaneService) { }

  ngOnInit() {
  }

}
