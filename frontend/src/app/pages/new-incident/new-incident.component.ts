import { IncidentsService } from './../../services/incidents.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-incident',
  templateUrl: './new-incident.component.html',
  styleUrls: ['./new-incident.component.css']
})
export class NewIncidentComponent implements OnInit {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private serviceIncident: IncidentsService,
    private router: Router
  ) {
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required]],
      value: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  handleSave(): void {
    this.serviceIncident.Post(this.form.getRawValue())
      .subscribe(() => {
        this.router.navigateByUrl('/profile');
      },
        err => {
          alert('Erro ao salvar caso, tente novamente!');
        });
  }

}
