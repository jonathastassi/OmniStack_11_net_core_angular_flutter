import { IncidentsService } from './../../services/incidents.service';
import { Incident } from './../../models/incident';
import { SessionsService } from './../../services/sessions.service';
import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  nameOng: string;

  incidents: Incident[];

  constructor(
    private serviceSession: SessionsService,
    private serviceProfile: ProfileService,
    private serviceIncident: IncidentsService,
  ) { }

  ngOnInit(): void {
    this.nameOng = this.serviceSession.getName();

    this.listIncidents();
  }

  listIncidents(): void {
    this.serviceProfile.Get()
      .subscribe(data => {
        this.incidents = data;
      },
        err => {
          alert('Erro na listagem dos casos, tente novamente!');
        });
  }

  handleDeleteIncident(id: number): void {
    this.serviceIncident.Delete(id)
      .subscribe(() => {
        this.listIncidents();
      },
        err => {

        });
  }

  logout(): void {
    this.serviceSession.Logout();
  }

}
